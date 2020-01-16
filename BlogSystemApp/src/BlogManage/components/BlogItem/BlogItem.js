import React from 'react';
import { Link } from 'react-router-dom';
import { Icon } from 'antd';
import './BlogItem.less';

const BlogItem = ({ bolgContent }) => {
    const Title = bolgContent.title;
    const UserName = 'Longfei Liu';
    const path = `/blogs/${bolgContent.id}`;

    return (
        <div className='blog-item'>
            <div className='blog-content'>
                <div className='item-header'>
                    <span className='user-name'>{UserName}</span>
                    <div className='tags'>
                        <Icon type="tags" />
                        <span>CSS</span>
                    </div>
                </div>
                <Link to={path}><p className='blog-title'>{Title}</p></Link>
            </div>
        </div>
    )
}

export default BlogItem;