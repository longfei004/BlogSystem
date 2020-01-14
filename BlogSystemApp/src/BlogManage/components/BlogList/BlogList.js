import React from 'react';
import BlogItem from '../BlogItem/BlogItem';
import './BlogList.less';

const BlogList = ({ blogs }) => {
    const blogList = blogs.map(blog => <BlogItem bolgContent={blog} key={'blog'+blog.id} />);

    return (
        <div className='blog-list'>
            {blogList}
        </div>
    )
}

export default BlogList;

