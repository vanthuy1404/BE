import React, { useState, useEffect } from "react";
import axios from "axios";
import StudentTable from "./StudentTable";
import StudentForm from "./StudentForm";
import SearchBar from "./SearchBar";
import AlertMessage from "./AlertMessage";

axios.defaults.withCredentials = true;

function QuanliSVremake() {
  const [dsSinhVien, setDsSinhVien] = useState([]);
  const [dsHienThi, setDsHienThi] = useState([]);
  const [searchText, setSearchText] = useState("");
  const [khoa, setKhoa] = useState([]);
  const [tenSV, setTenSV] = useState("");
  const [maSV, setMaSV] = useState(0);
  const [ngaySinh, setNgaySinh] = useState("");
  const [gioiTinh, setGioiTinh] = useState("Nam");
  const [maKhoa, setMaKhoa] = useState("CNTT");
  const [alert, setAlert] = useState({ show: false, type: "", message: "" });
  const [isGettingAdmission, setIsGettingAdmission] = useState(false);

  const API_URL = import.meta.env.VITE_API_URL;

  function fetchSinhVien() {
    axios
      .get(`${API_URL}/SinhVien`)
      .then((response) => {
        setDsSinhVien(response.data.data);
        setDsHienThi(response.data.data);
      })
      .catch((err) => console.error(err));
  }

  useEffect(() => {
    axios
      .get(`${API_URL}/Khoa`)
      .then((response) => setKhoa(response.data.data))
      .catch((err) => console.error(err));
  }, []);

  useEffect(() => {
    fetchSinhVien();
  }, []);

  const handleTimKiem = () => {
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
    setMaSV(0);
    setTenSV("");
    setNgaySinh("");
    setGioiTinh("Nam");
    setMaKhoa("CNTT");
  }

  const handleCreateSinhVien = () => {
    if (!tenSV || !ngaySinh) {
      setAlert({
        show: true,
        type: "danger",
        message: "Tên sinh viên và ngày sinh không được để trống!",
      });
      setTimeout(() => setAlert({ show: false, type: "", message: "" }), 3000);
      return;
    }
    axios
      .post(`${API_URL}/SinhVien`, {
        tenSV,
        ngaySinh,
        gioiTinh,
        maKhoa,
      })
      .then(() => {
        setAlert({
          show: true,
          type: "success",
          message: "Thêm sinh viên thành công!",
        });
        fetchSinhVien();
        clearForm();
        setTimeout(() => setAlert({ show: false, type: "", message: "" }), 3000);
      })
      .catch((error) => {
        if (error.response) {
          if (error.response.status === 401) {
            setAlert({
              show: true,
              type: "danger",
              message: "Chưa được cấp quyền!",
            });
          } else if (error.response.status === 400 && error.response.data?.message) {
            setAlert({
              show: true,
              type: "danger",
              message: error.response.data.message,
            });
          } else {
            setAlert({
              show: true,
              type: "danger",
              message: "Thêm sinh viên thất bại!",
            });
          }
        } else {
          setAlert({
            show: true,
            type: "danger",
            message: "Không thể kết nối tới máy chủ!",
          });
        }
        setTimeout(() => setAlert({ show: false, type: "", message: "" }), 3000);
      });
  };

  const handleUpdateSinhVien = () => {
    if (!tenSV) {
      setAlert({
      show: true,
      type: "danger",
      message: "Tên sinh viên không được để trống!",
      });
      setTimeout(() => setAlert({ show: false, type: "", message: "" }), 3000);
      return;
    }
    if (!ngaySinh) {
      setAlert({
      show: true,
      type: "danger",
      message: "Ngày sinh không được để trống!",
      });
      setTimeout(() => setAlert({ show: false, type: "", message: "" }), 3000);
      return;
    }
    axios
      .put(`${API_URL}/SinhVien`, {
        maSV,
        tenSV,
        ngaySinh,
        gioiTinh,
        maKhoa,
      })
      .then(() => {
        setAlert({
          show: true,
          type: "success",
          message: "Cập nhật sinh viên thành công!",
        });
        fetchSinhVien();
        clearForm();
        setTimeout(() => setAlert({ show: false, type: "", message: "" }), 3000);
      })
      .catch((error) => {
        handleAxiosError(error, "Cập nhật sinh viên thất bại!");
      });
  };

  const handleDeleteSinhVien = (maSV) => {
    if (window.confirm("Bạn có chắc chắn muốn xóa sinh viên này?")) {
      axios
        .delete(`${API_URL}/SinhVien/${maSV}`)
        .then(() => {
          setAlert({
            show: true,
            type: "success",
            message: "Xóa sinh viên thành công!",
          });
          fetchSinhVien();
          setTimeout(() => setAlert({ show: false, type: "", message: "" }), 3000);
        })
        .catch((error) => {
          handleAxiosError(error, "Xóa sinh viên thất bại!");
        });
    }
  };

  const handleEditSinhVien = (sv) => {
    setMaSV(sv.maSV);
    setTenSV(sv.tenSV);
    setNgaySinh(sv.ngaySinh.slice(0, 10));
    setGioiTinh(sv.gioiTinh);
    setMaKhoa(sv.maKhoa);
  };
  function handleGetAdmission() {
    axios.get(
      `${API_URL}/Authentication/login`,
      
      { withCredentials: true } 
    )
    .then(() => {
      setAlert({
        show: true,
        type: "success",
        message: "Lấy quyền thành công!",
      });
      setTimeout(() => setAlert({ show: false, type: "", message: "" }), 3000);
      setIsGettingAdmission(true);
    })
    .catch(() => {
      setAlert({
        show: true,
        type: "danger",
        message: "Lấy quyền thất bại!",
      });
      setTimeout(() => setAlert({ show: false, type: "", message: "" }), 3000);
    });
  }

  function handleAxiosError(error, defaultMsg) {
    console.error("AXIOS ERROR:", error);
    if (error.response && error.response.status === 401) {
      setAlert({
        show: true,
        type: "danger",
        message: "Chưa được cấp quyền!",
      });
    } else {
      setAlert({
        show: true,
        type: "danger",
        message: defaultMsg + (error.response?.data?.message ? ` (${error.response.data.message})` : ""),
      });
    }
    setTimeout(() => setAlert({ show: false, type: "", message: "" }), 3000);
  }

  return (
    <div className="container">
      <h2 className="text-center mt-3">Quản lí sinh viên</h2>

      <SearchBar
        searchText={searchText}
        onChange={(e) => {
          setSearchText(e.target.value);
          if (e.target.value === "") setDsHienThi(dsSinhVien);
        }}
        onSearch={handleTimKiem}
      />

      <StudentTable
        dsSinhVien={dsHienThi}
        onEdit={handleEditSinhVien}
        onDelete={handleDeleteSinhVien}
      />

      <h2 className="text-center mt-3">Thao tác với sinh viên</h2>
      <AlertMessage alert={alert} />
      <StudentForm
        maSV={maSV}
        tenSV={tenSV}
        ngaySinh={ngaySinh}
        gioiTinh={gioiTinh}
        maKhoa={maKhoa}
        khoa={khoa}
        onChangeTenSV={(e) => setTenSV(e.target.value)}
        onChangeNgaySinh={(e) => setNgaySinh(e.target.value)}
        onChangeGioiTinh={(e) => setGioiTinh(e.target.value)}
        onChangeMaKhoa={(e) => setMaKhoa(e.target.value)}
        onCreate={handleCreateSinhVien}
        onUpdate={handleUpdateSinhVien}
        onGetAdmission={handleGetAdmission}
        isGettingAdmission={isGettingAdmission}
      />
    </div>
  );
}

export default QuanliSVremake;