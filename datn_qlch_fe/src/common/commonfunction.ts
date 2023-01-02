import moment from 'moment'
const Commonfunction = {
  /**
  *Mô tả: Hàm clone data từ object để loại bỏ reactive
  *created by: VTSON 21-12-21
  */
  cloneData<T>(data: any): T {
    return JSON.parse(JSON.stringify(data))
  },

  /**
  *Mô tả: Hàm chuyển datetime thành định dạng DD-MM-YYYY
  *@param : date
  *created by: VTSON 02-01-02
  */
  formatDate(dateString: any): string {
    return moment(String(dateString)).format('DD-MM-YYYY')
  }
}

export default Commonfunction
