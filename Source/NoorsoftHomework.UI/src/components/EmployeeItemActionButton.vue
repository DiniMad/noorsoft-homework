<template>
  <button class="d-flex justify-content-center align-items-center">
    <font-awesome-icon :icon="icon" :class="classes"/>
  </button>
</template>

<script>
export default {
  name: "EmployeeItemActionButton",
  props:{
    icon:String,
    classes:String
  }
}
</script>

<style scoped lang="scss">
button{
  height: 2rem;
  width: 2rem;
  background: transparent;
  
  svg{
    font-size: 1.6rem;
  }
}
</style>