<template>
  <div id="employee-list" class="d-flex flex-column justify-content-between align-items-center p-5">
    <EmployeesListHeader/>
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

export default {
  name: "EmployeesList",
  props: {
    employees: Array
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