import React, { Component } from "react";
import axios from "axios";
import config from "./config";

import Header from "./components/Header/Header";
import Filters from "./components/Filters/Filters";
import List from "./components/List/List";
import PaginationTool from "./components/PaginationTool/PaginationTool";

import "./App.css";

class App extends Component {
  state = {
    postsData: {
      posts: []
    },
    pagination: {
      limit: 10,
      offset: 0,
      page: 1,
      total: 0
    },
    filterOptions: {
      lists: [],
      socialNetworks: []
    },
    filter: {
      content: "",
      initialDate: new Date(
        new Date().getFullYear(),
        new Date().getMonth(),
        new Date().getDate() - 10
      ),
      finalDate: new Date(
        new Date().getFullYear(),
        new Date().getMonth(),
        new Date().getDate()
      ),
      lists: [],
      socialNetworks: []
    }
  };

  componentDidMount() {
    this.getOptions();
    this.getFilteredPosts();
  }

  getOptions = () => {
    axios.get(`${config.API.URL}/post/options`).then(res => {
      const filterOptions = res.data;
      this.setState({ filterOptions });
    });
  };

  getFilteredPosts = (page = 1) => {
    const size = this.state.pagination.limit;
    axios
      .post(`${config.API.URL}/post/filter/${page}/${size}`, this.state.filter)
      .then(res => {
        const pagination = {
          ...this.state.pagination,
          offset: res.data.summary.listSize * (res.data.summary.pageIndex - 1),
          total: res.data.summary.returnedListSize
        };
        const postsData = res.data;
        this.setState({ postsData, pagination });
      });
  };

  handlePaginationClick = (_offset, page) => {
    this.getFilteredPosts(page);
  };

  handlePaginationLimitChange = e => {
    const { pagination } = this.state;
    pagination.limit = e.target.value;
    this.setState(pagination);
  };

  handleFilterChange = (value, filterAttr) => {
    const { filter } = this.state;
    filter[filterAttr] = value;
    this.setState(filter);
  };

  render() {
    return (
      <div className="App">
        <Header />
        <Filters
          options={this.state.filterOptions}
          filter={this.state.filter}
          click={this.getFilteredPosts}
          getFilteredPosts={this.getFilteredPosts}
          handleFilterChange={this.handleFilterChange}
        />
        <PaginationTool
          limit={this.state.pagination.limit}
          offset={this.state.pagination.offset}
          total={this.state.pagination.total}
          handlePaginationLimitChange={this.handlePaginationLimitChange}
          handlePaginationClick={this.handlePaginationClick}
        />

        <List posts={this.state.postsData.posts} />
      </div>
    );
  }
}

export default App;
