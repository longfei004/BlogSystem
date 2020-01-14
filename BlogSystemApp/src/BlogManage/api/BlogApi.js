
export const getBlogs = () =>
    fetch('https://localhost:5001/blogs')
        .then(response => response.json())
        .catch(() => alert('Can not get blogs!'));

export const getBlog = (id) =>
    fetch(`https://localhost:5001/blogs/${id}`)
        .then(response => response.json())
        .catch(() => alert('Can not get the blog!'));