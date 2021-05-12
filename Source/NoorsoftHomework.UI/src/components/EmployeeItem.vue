<template>
  <div class="employee-item position-relative rounded pb-1"
       :style="style"
       @mouseenter="mouseEnter"
       @mouseleave="mouseLeave">
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
      <EmployeeItemActionButton icon="trash" classes="text-danger" @clicked="onDelete"/>
      <div class="space"/>
      <EmployeeItemActionButton icon="edit" classes="text-primary" @clicked="onEdit"/>
      <div class="space"/>
      <EmployeeItemActionButton icon="plus" classes="text-success" @clicked="onNew"/>
    </div>
  </div>
  <Modal v-if="displayModal" @clicked-away="displayModal=false">
    <component :is="modalComponent"
               :employee="formEmployee"
               @canceled="displayModal=false"
               @done="OnModalDone"
               @confirmed="deleteConfirmed"
               :title="`${employee.firstName} ${employee.lastName} حذف شود؟`"/>
  </Modal>
</template>

<script>
import EmployeeItemDate from "@/components/EmployeeItemDate";
import EmployeeItemActionButton from "@/components/EmployeeItemActionButton";
import endpoints from "@/utilities/endpoints";
import axios from "axios";
import Modal from "@/components/Modal";
import EmployeeForm from "@/components/EmployeeForm";
import ConfirmForm from "@/components/ConfirmForm";

export default {
  name: "EmployeeItem",
  data: function () {
    return {
      isHovering: false,
      displayModal: false,
      modalComponent: "",
      formEmployee: {}
    }
  },
  props: {
    employee: Object,
    style: ""
  },
  computed: {
    fullName: function () {
      return `${this.employee.firstName} ${this.employee.lastName}`
    },
  },
  methods: {
    mouseEnter: function () {
      this.isHovering = true;
    },
    mouseLeave: function () {
      this.isHovering = false;
    },
    onDelete: async function () {
      this.modalComponent = "ConfirmForm"
      this.displayModal = true
    },
    onEdit: async function () {
      this.modalComponent = "EmployeeForm"
      this.formEmployee = this.employee
      this.displayModal = true
    },
    onNew: async function () {
      this.modalComponent = "EmployeeForm"
      this.formEmployee = {id: null, supervisorId: this.employee.id}
      this.displayModal = true
    },
    deleteConfirmed: async function () {
      this.displayModal = false
      const url = endpoints.api.deleteEmployee(this.employee.id)
      await axios.delete(url)
      this.$emit("reFetch")
    },
    OnModalDone: function () {
      this.displayModal = false
      this.$emit("reFetch")
    }
  },
  emits: ["reFetch"],
  components: {
    ConfirmForm,
    EmployeeForm,
    Modal,
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
