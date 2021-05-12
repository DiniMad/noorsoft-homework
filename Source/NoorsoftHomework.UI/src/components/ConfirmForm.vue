<template>
  <div id="delete" class="d-flex flex-column justify-content-center align-items-center">
    <h2 class="mb-5">{{title}}</h2>
    <div>
      <button class="bg-danger text-white fs-3 fw-bold rounded-pill mx-3 px-5 py-1"
              type="button"
              @click="$emit('canceled')">
        انصراف
      </button>
      <button class="bg-primary text-white fs-3 fw-bold rounded-pill mx-3 px-5 py-1"
              type="button"
              @click="$emit('confirmed')">
        تایید
      </button>
    </div>
  </div>
</template>

<script>
export default {
  name: "ConfirmForm",
  props: {
    title: String
  },
  emits: ["confirmed", "canceled"]
}
</script>
