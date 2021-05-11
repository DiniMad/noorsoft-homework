<template>
  <div id="employee-list" class="d-flex flex-column justify-content-between align-items-center p-5">
    <EmployeesListHeader @sort="sort"/>
    <div class="list d-flex justify-content-evenly align-items-start flex-wrap gap-5 mx-5">
      <EmployeeItem v-for="employee in employees" :employee="employee"/>
    </div>
    <EmployeesListFooter :total-count="totalCount"
                         :page-size="sortAndPagingResource.pageSize"
                         :page-number="sortAndPagingResource.pageNumber"
                         :has-previous="hasPrevious"
                         :has-next="hasNext"
                         @page-size-changed="onPageSizeChanged"
                         @previous="previous"
                         @next="next"/>
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
      totalCount: 0,
      hasPrevious: false,
      hasNext: false,
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
      this.totalCount = response.data.data.totalCount
      this.hasPrevious = Boolean(response.data.data.previous)
      this.hasNext = Boolean(response.data.data.next)
    },
    sort: function (parameters) {
      this.sortAndPagingResource.sortColumn = parameters.column
      this.sortAndPagingResource.sortDirection = parameters.direction
    },
    onPageSizeChanged: function (value) {
      this.sortAndPagingResource.pageSize = value
      this.sortAndPagingResource.pageNumber = 1
    },
    previous: function () {
      this.sortAndPagingResource.pageNumber--
    },
    next: function () {
      this.sortAndPagingResource.pageNumber++
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