<template>
  <div id="modal" class="d-flex justify-content-center align-items-center position-fixed top-0 start-0"
       @click="clickedAway">
    <div id="content">
      <slot/>
    </div>
  </div>
</template>

<script>
export default {
  name: "Modal",
  emits: ["clickedAway"],
  methods: {
    clickedAway: function (e) {
      if (e.target.id === "modal") this.$emit("clickedAway")
    }
  }
}
</script>

<style scoped lang="scss">
#modal {
  z-index: 2;
  width: 100vw;
  height: 100vh;
  background: #33333399;
  animation: appear 1s;

  @keyframes appear {
    from {
      opacity: 0;
    }
    to {
      opacity: 1;
    }
  }

  #content {
    padding: 5rem 10rem !important;
    background: #eee;
    border-radius: 3rem;
  }
}
</style>