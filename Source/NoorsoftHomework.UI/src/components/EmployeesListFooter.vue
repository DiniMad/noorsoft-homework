<template>
  <div id="footer" class="d-grid w-100">
    <div class="page-size d-flex justify-content-center align-items-center">
      <select class="fs-4 p-1">
        <option value="5">نمایش 5 مورد</option>
        <option value="10">نمایش 10 مورد</option>
        <option value="15">نمایش 15 مورد</option>
        <option value="20">نمایش 20 مورد</option>
      </select>
    </div>
    <div class="navigation d-flex justify-content-center align-items-center">
      <button class="navigation-button rounded-circle d-flex justify-content-center align-items-center">
        <font-awesome-icon icon="angle-left" class="fs-1"/>
      </button>
      <button class="page-number mx-3 fs-4 fw-bold selected">1</button>
      <button class="page-number mx-3 fs-4 fw-bold">2</button>
      <button class="page-number mx-3 fs-4 fw-bold">3</button>
      <button class="navigation-button rounded-circle d-flex justify-content-center align-items-center">
        <font-awesome-icon icon="angle-right" class="fs-1"/>
      </button>
    </div>
  </div>
</template>

<script>
export default {
  name: "EmployeesListFooter"
}
</script>

<style scoped lang="scss">
#footer {
  grid-template-columns: 2fr 5fr;

  .page-size {
    grid-column: 1;
    grid-row: 1;

    select {
      cursor: pointer;
    }
  }

  .navigation {
    grid-column: 1/3;
    grid-row: 1;

    .navigation-button {
      height: 4rem;
      width: 4rem;
      color: #111;
      background: #ddd;
      transition: background-color .5s, color .5s;

      &:hover {
        color: #fff;
        background: dodgerblue;
      }
    }

    .page-number {
      background: transparent;
      transition: color .5s;

      &:hover {
        color: dodgerblue;
      }

      &.selected {
        color: #1e74ff;
      }
    }
  }
}

</style>