<template>
  <div id="employee-list" class="d-flex flex-column justify-content-between align-items-center p-5">
    <EmployeesListHeader @sort="sort"/>
    <div class="list d-flex justify-content-evenly align-items-start flex-wrap gap-5 mx-5">
      <EmployeeItem v-for="employee in employees" :employee="employee"/>
    </div>
    <EmployeesListFooter/>
  </div>
</template>
<script>
import EmployeeItem from "@/components/EmployeeItem";
import EmployeesListHeader from "@/components/EmployeesListHeader";
import EmployeesListFooter from "@/components/EmployeesListFooter";
import axios from "axios"
import endpoints from "@/utilities/endpoints"

export default {
  name: "EmployeesList",
  data() {
    return {
      employees: [],
      sortAndPagingResource: {
        sortColumn: "firstName",
        sortDirection: "asc",
        pageSize: 5,
        pageNumber: 1
      }
    }
  },
  methods: {
    fetchEmployees: async function () {
      const response = await axios.get(endpoints.api.getEmployees, {params: this.sortAndPagingResource})
      if (response.status > 200) return;
      this.employees = response.data.data.collection
    },
    sort: function (parameters) {
      this.sortAndPagingResource.sortColumn = parameters.column
      this.sortAndPagingResource.sortDirection = parameters.direction
      this.test = !this.test
    }
  },
  watch: {
    sortAndPagingResource: {
      handler() {
        this.fetchEmployees();
      },
      deep: true
    }
  },
  created() {
    this.fetchEmployees();
  },
  components: {EmployeesListFooter, EmployeesListHeader, EmployeeItem}
}
</script>

<style scoped lang="scss">
#employee-list {
  height: 100vh;
  width: 100vw;
}

</style>