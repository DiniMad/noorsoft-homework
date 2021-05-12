<template>
  <div id="app" class="d-flex flex-column justify-content-between align-items-center p-5">
    <EmployeesListHeader @sort="onSorted"/>
    <EmployeesList :employees="employees" @re-fetch="reFetch"/>
    <EmployeesListFooter :total-count="totalCount"
                         :page-size="sortAndPagingResource.pageSize"
                         :page-number="sortAndPagingResource.pageNumber"
                         :has-previous="hasPrevious"
                         :has-next="hasNext"
                         @page-size-changed="onPageSizeChanged"
                         @previous="previous"
                         @next="next"
                         @re-fetch="reFetch"/>
  </div>
</template>

<script>
import EmployeesList from "@/components/EmployeesList";
import EmployeesListHeader from "@/components/EmployeesListHeader";
import EmployeesListFooter from "@/components/EmployeesListFooter";
import axios from "axios";
import endpoints from "@/utilities/endpoints";

export default {
  name: "App",
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
      const response = await axios.get(endpoints.api.getEmployees(), {params: this.sortAndPagingResource})
                                  .catch(error => this.$toast.error(error.response.data.errorMessage))
      if (response.status !== 200) return;
      this.employees = response.data.data.collection
      this.totalCount = response.data.data.totalCount
      this.hasPrevious = Boolean(response.data.data.previous)
      this.hasNext = Boolean(response.data.data.next)
    },
    onSorted: function (parameters) {
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
    },
    reFetch: function () {
      this.fetchEmployees();
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
  components: {
    EmployeesListFooter,
    EmployeesListHeader,
    EmployeesList,
  }
}
</script>

<style lang="scss">
* {
  margin: 0 !important;
  padding: 0 !important;
  box-sizing: border-box !important;
}

html {
  font-size: 10px !important;
}

button {
  border: none;
  outline: none;
}

.c-toast.c-toast--error{
  padding: 1.5rem !important;
  font-size: 1.4rem;
}

#app {
  height: 100vh;
  width: 100vw;
}
</style>
