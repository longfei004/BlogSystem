import React from 'react';
import { Link } from 'react-router-dom';
import { toLocalTime } from '../../../utils/DateUtils';
import UserLogo from '../../../assets/avatar.jpg';
import './BlogContent.less';

const BlogContent = ({ blog }) => {
    return (
        <div className='blog-view'>
            <p className='blog-view-title'>{blog.title}</p>
            <div className='blog-view-user'>
                <img className='user-logo-view' src={UserLogo} alt='This image is not exist!' />
                <div className='blog-info'>
                    <p className='name-info'>刘龙飞</p>
                    <p className='last-edit-date'>{toLocalTime(blog.lastUpdateTime)}</p>
                </div>
                <div className='back-home'>
                    <Link to='/'>返回首页</Link>
                </div>
            </div>
            <p className='blog-view-content'>{blog.content}</p>
        </div>
    )
}

export default BlogContent;
