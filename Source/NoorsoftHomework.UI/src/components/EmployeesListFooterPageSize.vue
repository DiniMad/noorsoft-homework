<template>
  <div id="page-size" class="d-flex justify-content-center align-items-center">
    <select class="fs-4 p-1" @change="onPageSizeChanged">
      <option v-for="number in [5,10,15,20]" :value="number" :selected="number===pageSize">
        نمایش {{ number }} مورد
      </option>
    </select>
  </div>
</template>

<script>
export default {
  name: "EmployeesListFooterPageSize",
  props: {
    pageSize: Number
  },
  methods: {
    onPageSizeChanged: function (e) {
      this.$emit("pageSizeChanged", Number(e.target.value))
    }
  }
}
</script>

<style scoped lang="scss">
#page-size {
  grid-column: 1;
  grid-row: 1;

  select {
    cursor: pointer;
  }
}
</style>