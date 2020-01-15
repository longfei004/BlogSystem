import React from 'react';
import { useState, useEffect } from 'react';
import { getBlogs } from '../../api/BlogApi';
import BlogTable from '../../components/BlogTable/BlogTable';
import './BlogManage.less';

const BlogManage = () => {
    const [blogs, setBlogs] = useState([]);

    useEffect(() => {
        getBlogs().then(result => {
            if (result !== undefined)
                setBlogs(result);
        });
    }, [])

    return (
        <div className='blog-manage'>
            <div className='blog-manage-container'>
                { blogs !== [] && <BlogTable blogs={blogs} />}
            </div>
        </div>
    )
}

export default BlogManage;