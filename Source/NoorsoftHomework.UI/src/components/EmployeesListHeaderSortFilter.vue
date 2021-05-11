<template>
  <button :class="templateClasses" @click="$emit('clicked',text)">
    <font-awesome-icon v-if="selected && ascending" icon="sort-amount-down-alt" class="sort-icon"/>
    <font-awesome-icon v-if="selected && !ascending" icon="sort-amount-up" class="sort-icon"/>
    <span class="fs-3">
    {{ text }}
    </span>
  </button>
</template>

<script>
export default {
  name: "EmployeesListHeaderSortFilter",
  props: {
    text: String,
    selected: Boolean,
    ascending: Boolean,
  },
  computed: {
    templateClasses: function () {
      return this.selected
             ? "template d-grid align-items-center rounded-pill fs-4 fw-bold text-center py-1 mx-4 px-2 selected"
             : "template d-grid align-items-center rounded-pill fs-4 fw-bold text-center py-1 mx-4 px-5"
    }
  }
}
</script>

<style scoped lang="scss">
.template {
  grid-template-columns: 1fr 5fr;
  background: #ddd;
  color: #555;
  transition: background-color .5s, color .5s;

  &:hover {
    background: dodgerblue;
    color: #fff;
  }

  &.selected {
    background: #1e74ff;
    color: #fff;
  }

  .sort-icon {
    grid-column: 1;
    grid-row: 1;
  }

  span {
    grid-column: 1/3;
    grid-row: 1;
  }
}
</style>