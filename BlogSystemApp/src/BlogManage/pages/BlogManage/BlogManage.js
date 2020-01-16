import React from 'react';
import { useState, useEffect } from 'react';
import { getBlogs, deleteBlog } from '../../api/BlogApi';
import BlogTable from '../../components/BlogTable/BlogTable';
import './BlogManage.less';

const BlogManage = () => {
    const [blogs, setBlogs] = useState([]);

    useEffect(() => {
        getBlogs().then(result => {
            if (result !== undefined)
                setBlogs(result);
        });
    }, []);

    const handleOnDelete = (id) => {
        const newBlogs = blogs.filter(blog => blog.id !== id);

        deleteBlog(id)
            .then(() => setBlogs(newBlogs));
    }

    return (
        <div className='blog-manage'>
            <div className='blog-manage-container'>
                { blogs !== [] && <BlogTable blogs={blogs} handleOnDelete={handleOnDelete}/>}
            </div>
        </div>
    )
}

export default BlogManage;