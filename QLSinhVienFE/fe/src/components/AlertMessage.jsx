import React from "react";

function AlertMessage({ alert }) {
  if (!alert.show) return null;
  return (
    <div
      className={`alert alert-${alert.type} alert-dismissible fade show mt-3`}
      role="alert"
    >
      {alert.message}
    </div>
  );
}

export default AlertMessage;