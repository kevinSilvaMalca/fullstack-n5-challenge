import { useEffect, useState } from "react";
import { getPermissions } from "../api/permissionsApi";
import { Typography, List, ListItem, ListItemText } from "@mui/material";

export default function PermissionList({ reload }) {
  const [permissions, setPermissions] = useState([]);

  useEffect(() => {
    getPermissions().then(res => setPermissions(res.data));
  }, [reload]);

  return (
    <>
      <Typography variant="h6">Lista de Permisos</Typography>
      <List>
        {permissions.map(p => (
          <ListItem key={p.id}>
            <ListItemText primary={`${p.employeeName} ${p.employeeLastName}`} secondary={`Tipo: ${p.permissionType} | Fecha: ${p.permissionDate}`} />
          </ListItem>
        ))}
      </List>
    </>
  );
}
