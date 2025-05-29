import { useState } from "react";
import PermissionForm from "./components/PermissionForm";
import PermissionList from "./components/PermissionList";
import { Container } from "@mui/material";

function App() {
  const [reload, setReload] = useState(false);

  return (
    <Container>
      <PermissionForm onSuccess={() => setReload(!reload)} />
      <PermissionList reload={reload} />
    </Container>
  );
}

export default App;
