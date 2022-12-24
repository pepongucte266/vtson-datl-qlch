const Commonfunction = {
  /**
  *Mô tả: Hàm clone data từ object để loại bỏ reactive
  *created by: VTSON 21-12-21
  */
  cloneData<T>(data: any): T {
    return JSON.parse(JSON.stringify(data))
  }
}

export default Commonfunction
