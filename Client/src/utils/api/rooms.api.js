import axios from "./axios";

export const getRoomsApi = () => {
  return axios.get("https://smartlivingapi.azurewebsites.net/api/House/4");
};

axios.defaults.headers.common['auth'] = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjdkYzAwYmU4LWEzZTQtNGU4ZC05ZjBhLTc2ZDBjN2JmZDRlOSIsIm5iZiI6MTY1ODQxMTc2MCwiZXhwIjoxNjU5MDE2NTYwLCJpYXQiOjE2NTg0MTE3NjB9.HDUhvOfj6ZxCVPirrahvk44GINAF_0c_gF3eNkkXw6o'