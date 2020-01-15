import React from 'react';
import { useState } from 'react';
import { postBlog } from '../../api/BlogApi';
import history from '../../../history';
import './BlogEdit.less';

const BlogEdit = () => {
    const [blog, setBlog] = useState();

    const handleOnBlogChange = (value) =>
        setBlog({
            ...blog,
            ...value
        });

    const handleOnPublish = () => {
        postBlog(blog)
            .then(result => '/blogs/' + result.id)
            .then(path => history.push(path));
    }

    return (
        <div className='blog-edit'>
            <div className='edit-container'>
                <div className='edit-title'>
                    <label>标题</label>
                    <input type='text' className='title-input' onChange={e => handleOnBlogChange({ title: e.target.value })} />
                </div>
                <div className='edit-content'>
                    <label>正文</label>
                    <textarea className='content-input' onChange={e => handleOnBlogChange({ content: e.target.value })} />
                </div>
                <div className='submit-type'>
                    <button className='publish-blog' onClick={() => handleOnPublish()}>发布</button>
                    <button className='go-back' onClick={() => history.goBack()}>返回</button>
                </div>
            </div>
        </div>
    )
};

export default BlogEdit;
