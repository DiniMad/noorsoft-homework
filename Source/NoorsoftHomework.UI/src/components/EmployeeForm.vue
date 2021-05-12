<template>
  <form id="edit-form" class="d-flex flex-column justify-content-evenly align-items-center">
    <div class="d-flex flex-column">
      <label for="firstName" class="fs-2 fw-bold text-center mb-2">نام</label>
      <input id="firstName" class="text fs-3" type="text" v-model.lazy.trim="employee.firstName"/>
    </div>
    <div class="d-flex flex-column">
      <label for="lastName" class="fs-2 fw-bold text-center mb-2">نام خانوادگی</label>
      <input id="lastName" class="text fs-3" type="text" v-model.lazy.trim="employee.lastName"/>
    </div>
    <div class="d-flex flex-column">
      <label for="birthDate" class="fs-2 fw-bold text-center mb-2">تاریخ تولد</label>
      <input id="birthDate" class="text fs-3" type="text" v-model.lazy.trim="employee.birthDate"
             placeholder="1400/1/1"/>
    </div>
    <div class="d-flex flex-column">
      <label for="recruitmentDate" class="fs-2 fw-bold text-center mb-2">تاریخ استخدام</label>
      <input id="recruitmentDate" class="text fs-3" type="text" v-model.lazy.trim="employee.recruitmentDate"
             placeholder="1400/1/1"/>
    </div>
    <div class="d-flex flex-column">
      <label for="supervisor" class="fs-2 fw-bold text-center mb-2">سرپرست</label>
      <select name="supervisor" id="supervisor" class="fs-3 p-1" v-model="employee.supervisorId">
        <option v-for="employee in supervisors"
                :value="employee.id"
                :selected="employee.id===employee.supervisorId" class="fs-3">
          {{ employee.firstName }} {{ employee.lastName }}
        </option>
      </select>
    </div>
    <div>
      <button class="bg-danger text-white fs-3 fw-bold rounded-pill mx-3 px-5 py-1"
              type="button"
              @click="onCancel">
        انصراف
      </button>
      <button class="bg-primary text-white fs-3 fw-bold rounded-pill mx-3 px-5 py-1"
              type="button"
              @click="onSubmit">
        ثبت
      </button>
    </div>
  </form>
</template>

<script>
import axios from "axios";
import endpoints from "@/utilities/endpoints";

export default {
  name: "EmployeeForm",
  data() {
    return {
      employees: []
    }
  },
  props: {
    employee: {
      type: Object,
      required: false,
      default: {
        id: null,
        firstName: "",
        lastName: "",
        birthDate: "",
        recruitmentDate: "",
        supervisorId: null,
      }
    }
  },
  computed: {
    supervisors() {
      const supervisors = [{id: null, firstName: "بدون", lastName: "سرپرست"}]
      supervisors.push(...this.employees)
      return supervisors
    },
    isCreateForm() {
      return this.employee.id === null
    }
  },
  emits: ["done", "canceled"],
  methods: {
    createRequest: async function () {
      const url = endpoints.api.createEmployee()
      await axios.post(url, this.employee).catch(error => this.$toast.error(error.response.data.errorMessage))
      this.$emit("done")
    },
    updateRequest: async function () {
      const url = endpoints.api.updateEmployee(this.employee.id)
      await axios.post(url, this.employee).catch(error => this.$toast.error(error.response.data.errorMessage))
      this.$emit("done")
    },
    onSubmit: function () {
      if (this.isCreateForm) this.createRequest()
      else this.updateRequest()
    },
    onCancel: function () {
      this.$emit("canceled")
    },
  },
  created: async function () {
    const response = await axios.get(endpoints.api.getEmployees(), {params: {pageSize: 9999}})
    if (response.status > 200) return;
    this.employees = response.data.data.collection
  }
}
</script>

<style scoped lang="scss">
#edit-form {
  height: 70vh;

  input {
    text-align: center;

    &.text {
      direction: rtl;
    }
  }

  button {
    opacity: .8;
    transition: opacity .5s;

    &:hover {
      opacity: 1;
    }
  }
}
</style>