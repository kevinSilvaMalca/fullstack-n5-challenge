import { useState } from "react";
import { Button, TextField, Grid, Typography } from "@mui/material";
import { requestPermission } from "../api/permissionsApi";

export default function PermissionForm({ onSuccess }) {
  const [form, setForm] = useState({
    employeeName: "",
    employeeLastName: "",
    permissionTypeId: 1,
    permissionDate: "",
  });

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = async () => {
    try {
      await requestPermission(form);
      onSuccess();
    } catch (err) {
      console.error(err);
      alert("Error al registrar permiso.");
    }
  };

  return (
    <Grid container spacing={2} sx={{ mb: 4 }}>
      <Grid item xs={12}><Typography variant="h6">Solicitar Permiso</Typography></Grid>
      <Grid item xs={6}><TextField label="Nombre" name="employeeName" fullWidth onChange={handleChange} /></Grid>
      <Grid item xs={6}><TextField label="Apellido" name="employeeLastName" fullWidth onChange={handleChange} /></Grid>
      <Grid item xs={6}><TextField label="Tipo ID" name="permissionTypeId" type="number" fullWidth onChange={handleChange} /></Grid>
      <Grid item xs={6}><TextField label="Fecha" name="permissionDate" type="date" fullWidth InputLabelProps={{ shrink: true }} onChange={handleChange} /></Grid>
      <Grid item xs={12}><Button variant="contained" onClick={handleSubmit}>Enviar</Button></Grid>
    </Grid>
  );
}
