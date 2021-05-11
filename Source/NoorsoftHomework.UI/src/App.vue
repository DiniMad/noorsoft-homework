<template>
  <EmployeesList/>
</template>

<script>
import EmployeesList from "@/components/EmployeesList";

export default {
  name: "App",
  components: {
    EmployeesList,
  }
}
</script>

<style lang="scss">
* {
  margin: 0 !important;
  padding: 0 !important;
  box-sizing: border-box !important;
}

html {
  font-size: 10px !important;
}

button {
  border: none;
  outline: none;
}

.employee-item {
  width: 25rem;
}
</style>
