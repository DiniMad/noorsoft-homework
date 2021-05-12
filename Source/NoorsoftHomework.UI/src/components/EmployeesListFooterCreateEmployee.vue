<template>
  <div id="create-employee" class="d-flex justify-content-center align-items-center">
    <button class="bg-primary text-white rounded fs-4 fw-bold py-2 px-4" @click="displayModal=true">
      کارمند جدید
    </button>
  </div>
  <Modal v-if="displayModal" @clicked-away="displayModal=false">
    <EmployeeForm :employee="{id:null,supervisorId:null}" @canceled="displayModal=false" @done="onCreated"/>
  </Modal>
</template>


<script>
import Modal from "@/components/Modal";
import EmployeeForm from "@/components/EmployeeForm";

export default {
  name: "EmployeesListFooterCreateEmployee",
  data() {
    return {
      displayModal: false
    }
  },
  methods: {
    onCreated: function () {
      this.displayModal = false
      this.$emit("reFetch")
    }
  },
  emits: ["reFetch"],
  components: {EmployeeForm, Modal}
}
</script>

<style scoped lang="scss">
#create-employee {
  grid-column: 3;
  grid-row: 1;

  button {
    transition: background-color .5s;

    &:hover {
      background: #1e47ff !important;
    }
  }
}
</style>