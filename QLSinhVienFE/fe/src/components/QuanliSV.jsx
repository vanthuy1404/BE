import React, { useState, useEffect } from "react";
import axios from "axios";
function QuanliSV() {
  const [dsSinhVien, setDsSinhVien] = useState([]);
  const [dsHienThi, setDsHienThi] = useState([]);
  const [searchText, setSearchText] = useState("");
  const [khoa, setKhoa] = useState([]);
  const [tenSV, setTenSV] = useState("");
  const [ngaySinh, setNgaySinh] = useState("");
  const [gioiTinh, setGioiTinh] = useState("");
  const [maKhoa, setMaKhoa] = useState("");

  const API_URL = import.meta.env.VITE_API_URL;
  function fetchSinhVien() {
    axios
      .get(`${API_URL}/SinhVien`)
      .then((response) => {
        setDsSinhVien(response.data.data);
        setDsHienThi(response.data.data);
        console.log(response.data.data);
      })
      .catch((err) => console.error(err));
  }
  useEffect(() => {
    axios
      .get(`${API_URL}/Khoa`)
      .then((response) => {
        console.log(response.data.data);
        setKhoa(response.data.data);
      })
      .catch((err) => console.error(err));
  }, []);
  useEffect(() => {
    fetchSinhVien();
  }, []);
  const handleTimKiem = () => {
    console.log("Tìm kiếm với từ khóa:", searchText);
    if (!searchText) {
      setDsHienThi(dsSinhVien);
      return;
    }
    const filteredData = dsSinhVien.filter((sv) => {
      return (
        sv.maSV == searchText ||
        sv.tenSV.toLowerCase().includes(searchText.toLowerCase()) ||
        sv.gioiTinh.toLowerCase().includes(searchText.toLowerCase()) ||
        sv.tenKhoa.toLowerCase().includes(searchText.toLowerCase())
      );
    });
    setDsHienThi(filteredData);
  };
  function clearForm() {
    setTenSV("");
    setNgaySinh("");
    setGioiTinh("");
    setMaKhoa("");
  }
  const handleCreateSinhVien = () =>{
    console.log("Tên SV:", tenSV);
    console.log("Ngày sinh:", ngaySinh);
    console.log("Giới tính:", gioiTinh);
    console.log("Mã Khoa:", maKhoa);
    axios.post(`${API_URL}/SinhVien`, {
      tenSV: tenSV,
      ngaySinh: ngaySinh,
      gioiTinh: gioiTinh,
      maKhoa: maKhoa,
    }).then((response) => {
      console.log("Thêm sinh viên thành công:", response.data);
      fetchSinhVien();
      clearForm(); 
    }).catch((err) => {
      console.error("Lỗi khi thêm sinh viên:", err);
    });
      
    
  }
  return (
    <>
      <div className="container">
        <h2 className="text-center mt-3">Quản lí sinh viên</h2>
        <div
          className="d-flex justify-content-center align-items-center mt-3"
          style={{ gap: "8px" }}
        >
          <input
            className="form-control me-2 d-inline-block"
            type="search"
            placeholder="Nhập thông tin tìm kiếm"
            aria-label="Tìm kiếm"
            style={{ width: "60%" }}
            onChange={(e) => {
              setSearchText(e.target.value);
              if (e.target.value === "") {
                setDsHienThi(dsSinhVien);
              }
            }}
          />
          <button
            className="btn btn-outline-success"
            type="submit"
            onClick={() => handleTimKiem(searchText)}
          >
            Search
          </button>
        </div>
        <table className="table mt-3">
          <thead className="table-light">
            <tr>
              <td>Mã Sinh viên</td>
              <td>Tên sinh viên</td>
              <td>Ngày sinh</td>
              <td>Giới tính</td>
              <td>Khoa</td>
              <td>Thao tác</td>
            </tr>
          </thead>
          <tbody>
            {!dsHienThi || dsHienThi.length === 0 ? (
              <tr>
                <td colSpan="5" className="text-center">
                  Danh sách trống
                </td>
              </tr>
            ) : (
              dsHienThi.map((sv, idx) => (
                <tr key={sv.maSV || idx}>
                  <td>{sv.maSV}</td>
                  <td>{sv.tenSV}</td>
                  <td>{new Date(sv.ngaySinh).toLocaleDateString("vi-VN")}</td>
                  <td>{sv.gioiTinh}</td>
                  <td>{sv.tenKhoa}</td>
                  <td>
                    <button
                      className="btn btn-dark"
                      style={{ marginRight: "5px" }}
                    >
                      Sửa
                    </button>
                    <button className="btn btn-danger">Xóa</button>
                  </td>
                </tr>
              ))
            )}
          </tbody>
        </table>
        <h2 className="text-center mt-3">Thao tác với sinh viên</h2>
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
            />
          </div>
          <div className="col-md-6">
            <label htmlFor="tenSV" className="form-label">
              Tên sinh viên
            </label>
            <input
              type="text"
              className="form-control"
              id="tenSV"
              value={tenSV}
              placeholder="Nhập tên sinh viên"
              onChange={(e) => setTenSV(e.target.value)}
            />
          </div>
          <div className="col-md-6">
            <label htmlFor="ngaySinh" className="form-label">
              Ngày sinh
            </label>
            <input
              type="date"
              className="form-control"
              id="ngaySinh"
              value={ngaySinh}
              onChange={(e) => setNgaySinh(e.target.value)}
            />
          </div>
          <div className="col-md-6">
            <label htmlFor="gioiTinh" className="form-label">
              Giới tính
            </label>
            <select
              id="gioiTinh"
              className="form-select"
              value={gioiTinh}
              onChange={(e) => setGioiTinh(e.target.value)}
            >
              <option value="Nam">Nam</option>
              <option value="Nữ">Nữ</option>
            </select>
          </div>
          <div className="col-md-12">
            <label htmlFor="khoa" className="form-label">
              Khoa
            </label>
            <select
              id="khoa"
              className="form-select"
              value={maKhoa}
              onChange={(e) => setMaKhoa(e.target.value)}
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
            <button type="button" className="btn btn-success" onClick={()=> handleCreateSinhVien()}>Thêm sinh viên</button>
            <button type = "button" className="btn btn-dark">Sửa sinh viên</button>
          </div>
        </form>
      </div>
    </>
  );
}
export default QuanliSV;
