import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:5147/api/permissions"
});

export const getPermissions = () => api.get("/");
export const requestPermission = (data) => api.post("/request", data);
export const modifyPermission = (data) => api.put("/modify", data);
