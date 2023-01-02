import { defineComponent, reactive, toRefs } from "vue";
import { useEmployeeStore } from "@/stores";
import { useRouter, useRoute } from 'vue-router'
export default defineComponent({
  setup() {
    const employeeStore = useEmployeeStore()
    const router = useRouter()
    const route = useRoute()
    const state = reactive({
      password: '',
      phonenumber: '',
      form: false,
      loading: false
    })

    function required (v: string) {
      return !!v || 'Field is required'
    }

    async function onSubmit () {
      if (!state.form) return

      state.loading = true
      const result = await employeeStore.login(state.phonenumber,state.password)
      if(result) {
        router.push('/')
      }
      state.loading = false
    }

    return {
      ...toRefs(state),
      onSubmit,
      required
    }
  }
});
