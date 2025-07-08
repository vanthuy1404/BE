import React from "react";

function SearchBar({ searchText, onChange, onSearch }) {
  return (
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
        value={searchText}
        onChange={onChange}
      />
      <button
        className="btn btn-outline-success"
        type="button"
        onClick={onSearch}
      >
        Search
      </button>
    </div>
  );
}

export default SearchBar;