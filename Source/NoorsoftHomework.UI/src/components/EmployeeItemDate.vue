<template>
  <div :class="wrapperClasses">
    <div class="years d-flex justify-content-center align-items-center">
      <font-awesome-icon :icon="icon"/>
      <div class="m-1"/>
      <p class="fs-3">{{ years }} سال</p>
    </div>
    <div class="date text-center fs-5">{{ date }}</div>
  </div>
</template>

<script>
export default {
  name: "EmployeeItemDate",
  props: {
    isHovering: Boolean,
    years: Number,
    date: String,
    icon: String
  },
  computed: {
    wrapperClasses: function () {
      return this.isHovering
             ? "hovering wrapper d-flex flex-column"
             : "wrapper d-flex flex-column"
    },
  }
}
</script>

<style scoped lang="scss">
.wrapper {
  direction: rtl;

  &.hovering {
    .years {
      transform: translateY(0);
    }

    .date {
      opacity: 1;
    }
  }

  .years {
    transform: translateY(10px);
    transition: transform .5s;

    svg {
      font-size: 2rem;
    }
  }

  .date {
    opacity: 0;
    transition: opacity .5s;
  }
}
</style>