import React from 'react';
import './BlogItem.less';

const BlogItem = ({bolgContent}) => {

    console.log(bolgContent);
    
    const Title = bolgContent.title;

    return (
        <div className='blog-item'>
            <div className='blog-content'>
                <p className='blog-category'>前端</p>
                <p className='blog-title'>{Title}</p>
                <p className='blog-tag'>CSS</p>
            </div>
        </div>
    )
}

export default BlogItem;