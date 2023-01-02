import axios from "axios";
import CONFIG from "@/common/config";
import type IEmployee from "@/interface/IEmployee";

class EmployeeService {
  async getall(): Promise<IEmployee[]> {
    var endpoint = "Employee";
    const response = await axios.get(CONFIG.BaseURL + endpoint);
    return response.data;
  }
}

export default new EmployeeService();
