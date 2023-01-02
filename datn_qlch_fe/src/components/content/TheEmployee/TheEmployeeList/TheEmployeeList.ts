import { defineComponent, reactive, toRefs, ref } from "vue";
import { mdiArchivePlusOutline, mdiNoteEdit, mdiDelete } from "@mdi/js";
import * as Enum from "@/common/enum";
import type IEmployee from "@/interface/IEmployee";
import EmployeeService from "@/services/EmployeeService";
import QLCHDialog from '@/components/base/QLCHDialog/QLCHDialog.vue'
import Commonfunction from "@/common/commonfunction";
import TheEmployeeDetail from "../TheEmployeeDetail/TheEmployeeDetail.vue";
export default defineComponent({
  components: {
    QLCHDialog,
    TheEmployeeDetail
  },
  setup() {
    /**
    *Mô tả: Ref template cho dialog
    *created by: VTSON 01-01-01
    */
    const qlchDialog = ref<InstanceType<typeof QLCHDialog> | null>()

    const state = reactive({
      employees: [] as IEmployee[],
      dialogMessage: '',
      showDialog: false,
      dialogTitle: 'Cảnh báo',
      today: new Date(),
      currentEmployeeID: '',
      action: Enum.Action.Insert,
      showEmployeeDetail: false
    })

    async function loadData() {
      state.employees = await EmployeeService.getall();
    }

    async function deleteEmployee(employee: IEmployee) {
      var result = false
      state.dialogMessage = `Bạn có muốn xóa nhân viên <strong>${employee.EmployeeName}</strong> không?`
      state.showDialog = true;
    }

    async function openEmployeeDetail(action: Enum.Action, employeeID?:string) {
      if(employeeID) {
        state.currentEmployeeID = employeeID
      }
      state.action = action
      state.showEmployeeDetail = true
    }

    loadData()

    return {
      ...toRefs(state),
      mdiArchivePlusOutline,
      Enum,
      mdiNoteEdit,
      mdiDelete,
      deleteEmployee,
      openEmployeeDetail,
      Commonfunction
    };
  },
});
