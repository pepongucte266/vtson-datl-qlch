import axios from "axios";
import CONFIG from "@/common/config";
import * as Enum from "@/common/enum"

class AuthService {
  async Login(phone: string, password: string) {
    if(!phone || !password) return;
    const url = CONFIG.BaseURL + CONFIG.Endpoint.Auth.Login
    const params = {
      PhoneNumber: phone,
      Password: password
    }
    var token = ''
    try {
      await axios.post(url,params).then(response => {
        token = response.data
      })
      return token
    } catch (err) {
      return false
    }
    
  }
}

export default new AuthService();
