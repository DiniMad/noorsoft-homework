<template>
  <div class="employee-item position-relative rounded pb-1" @mouseenter="mouseEnter" @mouseleave="mouseLeave">
    <font-awesome-icon v-if="employee.isManager" icon="star" class="position-absolute top-0 end-0 fs-2 text-primary"/>
    <p class="text-center fs-1">{{ fullName }}</p>
    <div class="d-flex justify-content-evenly">
      <EmployeeItemDate :years="employee.workExperienceInYears"
                        :date="employee.birthDate"
                        :is-hovering="isHovering"
                        icon="briefcase"/>
      <EmployeeItemDate :years="employee.ageInYears"
                        :date="employee.recruitmentDate"
                        :is-hovering="isHovering"
                        icon="birthday-cake"/>
    </div>
    <div class="action-menu position-absolute d-flex justify-content-center align-items-center rounded-bottom">
      <EmployeeItemActionButton icon="trash" classes="text-danger"/>
      <div class="space"/>
      <EmployeeItemActionButton icon="edit" classes="text-primary"/>
      <div class="space"/>
      <EmployeeItemActionButton icon="plus" classes="text-success"/>
    </div>
  </div>
</template>

<script>
import EmployeeItemDate from "@/components/EmployeeItemDate";
import EmployeeItemActionButton from "@/components/EmployeeItemActionButton";

export default {
  name: "EmployeeItem",
  data: function () {
    return {
      isHovering: false
    }
  },
  props: {
    employee: Object
  },
  computed: {
    fullName: function () {
      return `${this.employee.firstName} ${this.employee.lastName}`
    },
  },
  methods: {
    mouseEnter: function () {
      this.isHovering = true;
    }, mouseLeave: function () {
      this.isHovering = false;
    }
  },
  components: {
    EmployeeItemActionButton,
    EmployeeItemDate
  }
}
</script>

<style scoped lang="scss">
.employee-item {
  cursor: default;
  background: #eee;
  transition: background-color .5s;
  transform: translateY(0);

  &:hover {
    background: #ddd;

    .wrapper {
      transform: translateY(0);
    }

    .action-menu {
      opacity: 1;
    }
  }

  .action-menu {
    height: 2rem;
    bottom: -2rem;
    right: 3rem;
    opacity: 0;
    background: #ddd;
    transition: opacity .5s;

    .space {
      margin: 0 .2rem 0 .2rem !important;
    }
  }
}
</style>
