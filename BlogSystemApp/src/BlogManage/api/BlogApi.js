
export const getBlogs = () =>
fetch('https://localhost:5001/blogs')
.then(response => response.json())
.catch(() => alert('Can not get blogs!'));