import React from "react";

function StudentTable({ dsSinhVien, onEdit, onDelete }) {
  return (
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
        {!dsSinhVien || dsSinhVien.length === 0 ? (
          <tr>
            <td colSpan="6" className="text-center">
              Danh sách trống
            </td>
          </tr>
        ) : (
          dsSinhVien.map((sv, idx) => (
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
                  onClick={() => onEdit(sv)}
                >
                  Sửa
                </button>
                <button
                  className="btn btn-danger"
                  onClick={() => onDelete(sv.maSV)}
                >
                  Xóa
                </button>
              </td>
            </tr>
          ))
        )}
      </tbody>
    </table>
  );
}

export default StudentTable;