<template>
  <div id="footer" class="d-grid w-100">
    <EmployeesListFooterPageSize :page-size="pageSize"
                                 @page-size-changed="size=>$emit('pageSizeChanged', size)"/>
    <EmployeesListFooterPageNavigation :page-number="pageNumber"
                                       :has-previous="hasPrevious"
                                       :has-next="hasNext"
                                       @previous="$emit('previous')"
                                       @next="$emit('next')"/>
    <EmployeesListFooterCreateEmployee @re-fetch="$emit('reFetch')"/>
  </div>
</template>

<script>
import EmployeesListFooterPageSize from "@/components/EmployeesListFooterPageSize";
import EmployeesListFooterPageNavigation from "@/components/EmployeesListFooterPageNavigation";
import EmployeesListFooterCreateEmployee from "@/components/EmployeesListFooterCreateEmployee";

export default {
  name: "EmployeesListFooter",
  props: {
    pageSize: Number,
    pageNumber: Number,
    hasPrevious: Boolean,
    hasNext: Boolean,
  },
  emits: ["pageSizeChanged", "previous", "next", "reFetch"],
  components: {
    EmployeesListFooterCreateEmployee,
    EmployeesListFooterPageNavigation,
    EmployeesListFooterPageSize
  }
}
</script>

<style scoped lang="scss">
#footer {
  grid-template-columns: repeat(3, 1fr);
}

</style>