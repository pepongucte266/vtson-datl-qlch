import { defineStore } from "pinia";
import AuthService from "@/services/AuthService";
import type IEmployee from "@/interface/IEmployee"
export const useEmployeeStore = defineStore("employee", {
  state: () => ({ 
    currentEmployee: {} as IEmployee
  }),
  actions: {
    async login(phone: string, password: string) {
      const result = await AuthService.Login(phone, password);
      if(result) {
        this.currentEmployee.PhoneNumber = phone
        this.currentEmployee.Token = result
        return true;
      } else {
        return false;
      }
    }
  }
  
})
