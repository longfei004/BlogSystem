
export const getBlogs = () =>
    fetch('https://localhost:5001/blogs')
        .then(response => response.json())
        .catch(() => alert('Can not get blogs!'));

export const getBlog = (id) =>
    fetch(`https://localhost:5001/blogs/${id}`)
        .then(response => response.json())
        .catch(() => alert('Can not get the blog!'));

export const postBlog = (blog) =>
    fetch('https://localhost:5001/blogs', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(blog)
    }).then(response => response.json())
    .catch(() => alert('Can not save the blog!'));

export const modifyBlog = (id, blog) =>
    fetch(`https://localhost:5001/blogs/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(blog)
    })
    .catch(() => alert('Can not save the blog!'));

export const deleteBlog = (id) =>
    fetch(`https://localhost:5001/blogs/${id}`, {
        method: 'DELETE',
    })
    .catch(() => alert('Can not delete the blog!'));