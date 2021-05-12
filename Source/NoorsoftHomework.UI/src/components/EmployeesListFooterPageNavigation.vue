<template>
  <div id="navigation" class="d-flex justify-content-center align-items-center">
    <button class="navigation-button rounded-circle d-flex justify-content-center align-items-center"
            :disabled="hasPrevious===false"
            @click="$emit('previous')">
      <font-awesome-icon icon="angle-left" class="fs-1"/>
    </button>
    <p v-for="page in pages"
       :class="`page-number fs-4 fw-bold mx-3 ${page.selected && 'selected'}`">
      {{ page.number }}
    </p>
    <button class="navigation-button rounded-circle d-flex justify-content-center align-items-center"
            :disabled="hasNext===false"
            @click="$emit('next')">
      <font-awesome-icon icon="angle-right" class="fs-1"/>
    </button>
  </div>
</template>

<script>
export default {
  name: "EmployeesListFooterPageNavigation",
  data() {
    return {
      pages: []
    }
  },
  props: {
    pageNumber: Number,
    hasNext: Boolean,
    hasPrevious: Boolean,
  },
  methods: {
    generatePages: function () {
      const pages = [];
      if (this.hasPrevious === true) pages.push({number: this.pageNumber - 1, selected: false})
      pages.push({number: this.pageNumber, selected: true})
      if (this.hasNext === true) pages.push({number: this.pageNumber + 1, selected: false})
      this.pages = pages;
    }
  },
  watch: {
    pageNumber() {
      this.generatePages()
    },
    hasNext() {
      this.generatePages()
    },
    hasPrevious() {
      this.generatePages()
    },
  },
  created() {
    this.generatePages()
  }
}
</script>

<style scoped lang="scss">
#navigation {
  grid-column: 2;
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

    &:disabled {
      color: #888;
      background: #eee;
    }
  }

  .page-number {
    cursor: default;
    background: transparent;
    transition: color .5s;

    &.selected {
      color: #1e74ff;
    }
  }
}

</style>