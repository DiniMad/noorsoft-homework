<template>
  <div class="d-flex justify-content-center align-items-center">
    <EmployeesListHeaderSortFilter v-for="filter in filters"
                                   :text="filter.name"
                                   :selected="filter.selected"
                                   :ascending="filter.ascending"
                                   @clicked="onSortFilterClicked"/>
  </div>

</template>

<script>
import EmployeesListHeaderSortFilter from "@/components/EmployeesListHeaderSortFilter";

export default {
  name: "EmployeesListHeader",
  data() {
    return {
      filters: [
        {key: "recruitmentDate", name: "سابقه", selected: false, ascending: false},
        {key: "birthDate", name: "سن", selected: false, ascending: false},
        {key: "firstName", name: "نام", selected: true, ascending: false},
      ]
    }
  },
  methods: {
    revertDirection: function (name) {
      return this.filters.map(filter => {
        if (filter.name !== name) return filter
        return {
          key: filter.key,
          name: filter.name,
          selected: filter.selected,
          ascending: !filter.ascending
        }
      });
    },
    changeSelected: function (name) {
      return this.filters.map(filter => {
        return {
          key: filter.key,
          name: filter.name,
          selected: filter.name === name,
          ascending: true
        }
      })
    },
    emitFilter: function (updatedFilters, name) {
      const selectedFilter = updatedFilters.filter(filter => filter.name === name)[0]
      const sortParameters = {
        column: selectedFilter.key,
        direction: selectedFilter.ascending
                   ? "asc"
                   : "desc"
      }
      this.$emit("sort", sortParameters)
    },
    onSortFilterClicked: function (name) {
      const item = this.filters.filter(filter => filter.name === name)[0]
      const updatedFilters = item.selected === true
                             ? this.revertDirection(name)
                             : this.changeSelected(name);
      this.filters = updatedFilters;
      this.emitFilter(updatedFilters, name);
    }
  },
  components: {EmployeesListHeaderSortFilter}
}
</script>

<style scoped>

</style>