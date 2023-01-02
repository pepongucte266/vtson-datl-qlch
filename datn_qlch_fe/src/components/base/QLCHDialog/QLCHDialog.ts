import { defineComponent, reactive, toRefs, computed} from 'vue'
export default defineComponent({
  props: {
    title: String,
    message: String,
    isShow: Boolean,
  },
  emits: ['isShowDialog'],
  setup(props,{emit}) {
    var show = computed({
      get() {
        return props.isShow
      },
      set(value) {
        emit("isShowDialog", value);
      }
    })

    var resolvePromise: (value: boolean) => void = () => {};

    function getResult(): Promise<boolean> {
      return new Promise((resolve) => {
        return (resolvePromise = resolve);
      });
    }
    function confirm() {
      emit("isShowDialog", false);
      resolvePromise(true);
    }
    function cancel() {
      emit("isShowDialog", false);
      resolvePromise(false);
    }

    return { show, getResult, confirm, cancel };
  }
})
