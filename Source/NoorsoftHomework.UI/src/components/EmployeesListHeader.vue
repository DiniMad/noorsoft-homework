<template>
  <div class="d-flex justify-content-center align-items-center">
    <EmployeesListHeaderSortFilter text="سابقه" :selected="false"/>
    <div class="mx-3"/>
    <EmployeesListHeaderSortFilter text="سن" :selected="false"/>
    <div class="mx-3"/>
    <EmployeesListHeaderSortFilter text="نام" :selected="true"/>
  </div>

</template>

<script>
import EmployeesListHeaderSortFilter from "@/components/EmployeesListHeaderSortFilter";
export default {
  name: "EmployeesListHeader",
  components: {EmployeesListHeaderSortFilter}
}
</script>

<style scoped>

</style>