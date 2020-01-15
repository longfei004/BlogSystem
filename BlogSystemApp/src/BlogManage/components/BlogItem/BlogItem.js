import React from 'react';
import {Link} from "react-router-dom";
import './BlogItem.less';

const BlogItem = ({bolgContent}) => {
    const Title = bolgContent.title;
    const path = `/blogs/${bolgContent.id}`;

    return (
        <div className='blog-item'>
            <div className='blog-content'>
                <p className='blog-category'>前端</p>
                <Link to={path}><p className='blog-title'>{Title}</p></Link>
                <p className='blog-tag'>CSS</p>
            </div>
        </div>
    )
}

export default BlogItem;