<template>
  <div class="list d-flex flex-row-reverse justify-content-evenly align-items-start flex-wrap gap-5 mx-5">
    <div v-if="employees.length===0" class="fs-3 fw-bold">
      کارمندی ایجاد نشده است
    </div>
    <EmployeeItem v-for="employee in employees"
                  :employee="employee"
                  style="width: 25rem;"
                  @re-fetch="$emit('reFetch')"/>
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
  props: {
    employees: Array
  },
  emits: ["reFetch"],
  components: {EmployeesListFooter, EmployeesListHeader, EmployeeItem}
}
</script>