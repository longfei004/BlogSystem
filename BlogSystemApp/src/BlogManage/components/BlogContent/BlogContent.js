import React from 'react';
import UserLogo from '../../../assets/avatar.jpg';
import './BlogContent.less';

const BlogContent = ({ blog }) => {
    return (
        <div className='blog-view'>
            <p className='blog-view-title'>{blog.title}</p>
            <div className='blog-view-user'>
                <img className='user-logo-view' src={UserLogo} alt='This image is not exist!'/>
                <div className='blog-info'>
                    <p className='name-info'>刘龙飞</p>
                    <p className='last-edit-date'>2020.01.01 20:00:00</p>
                </div>
            </div>
            <p className='blog-view-content'>{blog.content}</p>
        </div>
    )
}

export default BlogContent;
