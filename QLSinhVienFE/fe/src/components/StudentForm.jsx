import React from "react";

function StudentForm({
  maSV,
  tenSV,
  ngaySinh,
  gioiTinh,
  maKhoa,
  khoa,
  onChangeTenSV,
  onChangeNgaySinh,
  onChangeGioiTinh,
  onChangeMaKhoa,
  onCreate,
  onUpdate,
  onGetAdmission,
  isGettingAdmission,
}) {
  return (
    <form className="row g-3 mt-2">
      <div className="col-md-6">
        <label htmlFor="maSV" className="form-label">
          Mã sinh viên
        </label>
        <input
          type="text"
          className="form-control"
          id="maSV"
          placeholder="Mã sinh viên"
          readOnly
          value={maSV}
        />
      </div>
      <div className="col-md-6">
        <label htmlFor="tenSV" className="form-label">
          Tên sinh viên <span style={{ color: "red" }}>*</span>
        </label>
        <input
          type="text"
          className="form-control"
          id="tenSV"
          value={tenSV}
          placeholder="Nhập tên sinh viên"
          required
          onChange={onChangeTenSV}
        />
      </div>
      <div className="col-md-6">
        <label htmlFor="ngaySinh" className="form-label">
          Ngày sinh <span style={{ color: "red" }}>*</span>
        </label>
        <input
          type="date"
          className="form-control"
          id="ngaySinh"
          value={ngaySinh}
          required
          onChange={onChangeNgaySinh}
        />
      </div>
      <div className="col-md-6">
        <label htmlFor="gioiTinh" className="form-label">
          Giới tính <span style={{ color: "red" }}>*</span>
        </label>
        <select
          id="gioiTinh"
          className="form-select"
          value={gioiTinh}
          onChange={onChangeGioiTinh}
        >
          <option value="Nam">Nam</option>
          <option value="Nữ">Nữ</option>
        </select>
      </div>
      <div className="col-md-12">
        <label htmlFor="khoa" className="form-label">
          Khoa <span style={{ color: "red" }}>*</span>
        </label>
        <select
          id="khoa"
          className="form-select"
          value={maKhoa}
          onChange={onChangeMaKhoa}
        >
          {khoa.map((k) => (
            <option key={k.maKhoa} value={k.maKhoa}>
              {k.tenKhoa}
            </option>
          ))}
        </select>
      </div>
      <div
        className="col-12 d-flex justify-content-center align-items-center mb-5"
        style={{ gap: "10px" }}
      >
        <button type="button" className="btn btn-success" onClick={onCreate}>
          Thêm sinh viên
        </button>
        <button type="button" className="btn btn-dark" onClick={onUpdate}>
          Cập nhật
        </button>
        <button type="button" className="btn btn-info" onClick={onGetAdmission} disabled = {isGettingAdmission}>
          Lấy quyền
        </button>
      </div>
    </form>
  );
}

export default StudentForm;
