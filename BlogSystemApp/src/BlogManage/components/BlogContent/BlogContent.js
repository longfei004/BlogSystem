import React from 'react';
import './BlogContent.less';

const BlogContent = ({ blog }) => {
    return (
        <div className='blog-detail'>
            <p className='blog-title'>{blog.title}</p>
            <hr />
            <p className='blog-content'>{blog.content}</p>
        </div>
    )
}

export default BlogContent;
