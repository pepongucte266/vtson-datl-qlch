import type IEmployee from "@/interface/IEmployee";
import type { PropType } from 'vue'
import type * as Enum from "@/common/enum"
import { defineComponent, reactive, toRefs, computed } from "vue";
import Commonfunction from "@/common/commonfunction";
export default defineComponent({
  props: {
    showEmployeeDetail: Boolean,
    employeeID: String,
    action: {
      type: Number as PropType<Enum.Action>,
      required: true,
    },
  },
  emit: ['change'],
  setup(props, {emit}) {
    const state = reactive({
      menu2: false,
      employee: {
        EmployeeName: '',
        PhoneNumber: '',
        DateOfBirth: '01-03-1985',
        Address: '',
        Role: ''
      } as IEmployee,
    })

    var show: any = computed<boolean>({
      get() {
        return props.showEmployeeDetail
      },
      set(value: boolean) {
        emit('change', value);
      }
    })

    var computedDate = computed(() => {
      return state.employee.DateOfBirth? Commonfunction.formatDate(state.employee.DateOfBirth) : ''
    })

    return {
      ...toRefs(state),
      show,
      computedDate,
      picker: (new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000)).toISOString().substr(0, 10)
    }
  }
})
