<template>
  <div id="footer" class="d-grid w-100">
    <EmployeesListFooterPageSize :page-size="pageSize" 
                                 @page-size-changed="size=>$emit('pageSizeChanged', size)"/>
    <EmployeesListFooterPageNavigation :page-number="pageNumber"
                                       :has-previous="hasPrevious"
                                       :has-next="hasNext"
                                       @previous="$emit('previous')"
                                       @next="$emit('next')"/>
  </div>
</template>

<script>
import EmployeesListFooterPageSize from "@/components/EmployeesListFooterPageSize";
import EmployeesListFooterPageNavigation from "@/components/EmployeesListFooterPageNavigation";

export default {
  name: "EmployeesListFooter",
  components: {EmployeesListFooterPageNavigation, EmployeesListFooterPageSize},
  props: {
    pageSize: Number,
    pageNumber: Number,
    hasPrevious: Boolean,
    hasNext: Boolean,
  }
}
</script>

<style scoped lang="scss">
#footer {
  grid-template-columns: 2fr 5fr;
}

</style>