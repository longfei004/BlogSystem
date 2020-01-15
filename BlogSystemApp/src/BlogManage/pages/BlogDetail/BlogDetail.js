import React from 'react';
import { useEffect, useState } from 'react';
import { getBlog } from '../../api/BlogApi';
import BlogContent from '../../components/BlogContent/BlogContent';
import './BlogDetail.less';

const BlogDetail = (props) => {
    const [blog, setBlog] = useState();
    const blogId = props.match.params.id;

    useEffect(() => {
        getBlog(blogId).then(result => setBlog(result));
    }, [])

    return (
        <div className='blog-container'>
            <div className='detail-side-bar'></div>
            {blog !== undefined && <BlogContent blog={blog} />}
        </div>
    )
}

export default BlogDetail;