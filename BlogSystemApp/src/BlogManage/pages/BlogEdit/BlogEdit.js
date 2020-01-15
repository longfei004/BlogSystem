import React from 'react';
import { useState, useEffect } from 'react';
import { postBlog, getBlog, modifyBlog } from '../../api/BlogApi';
import history from '../../../history';
import './BlogEdit.less';

const BlogEdit = (props) => {
    const [blog, setBlog] = useState();

    const blogId = props.match.params.id;

    useEffect(() => {
        if (blogId !== undefined)
            getBlog(blogId).then(result => {
                if (result !== undefined)
                    setBlog(result);
        });
    }, []);

    const handleOnBlogChange = (value) =>
        setBlog({
            ...blog,
            ...value
        });

    const handleOnPublish = () => {
        if (blogId !== undefined) {
            modifyBlog(blogId, blog)
                .then(() => history.push(`/blogs/${blogId}`));
        } else {
            postBlog(blog)
                .then(result => '/blogs/' + result.id)
                .then(path => history.push(path));
        }
    }

    return (
        <div className='blog-edit'>
            <div className='edit-container'>
                <div className='edit-title'>
                    <label>标题</label>
                    <input type='text' className='title-input'
                        onChange={e => handleOnBlogChange({ title: e.target.value })}
                        defaultValue={blog !== undefined ? blog.title : ''}
                    />
                </div>
                <div className='edit-content'>
                    <label>正文</label>
                    <textarea className='content-input' 
                        onChange={e => handleOnBlogChange({ content: e.target.value })} 
                        defaultValue={blog !== undefined ? blog.content : ''}
                    />
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
